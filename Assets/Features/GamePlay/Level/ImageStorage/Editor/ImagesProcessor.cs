using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GamePlay.Level.ImageStorage.Common;
using GamePlay.Level.ImageStorage.Runtime;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Level.ImageStorage.Editor
{
    [CreateAssetMenu(fileName = ImageStorageRoutes.ProcessorName,
        menuName = ImageStorageRoutes.ProcessorPath)]
    public class ImagesProcessor : ScriptableObject
    {
        [SerializeField] private int[] _levelsSlices = { 4, 6, 8, 10 };

        [SerializeField] private Texture2D[] _images;

        [SerializeField] private LevelImage[] _assets;

        [Button]
        private void Process()
        {
            for (var i = 0; i < _images.Length; i++)
                OnPostprocessTexture(_images[i], _assets[i]);
        }

        private void OnPostprocessTexture(Texture2D texture, LevelImage asset)
        {
            var assetPath = AssetDatabase.GetAssetPath(texture);
            var textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;

            if (textureImporter == null)
                throw new NullReferenceException();

            var fileName = Path.GetFileNameWithoutExtension(assetPath);

            var rects = new List<Rect>();

            foreach (var slice in _levelsSlices)
            {
                var height = Mathf.FloorToInt((float)texture.height / slice);

                for (var i = 0; i < slice; i++)
                {
                    var rectPosition = new Vector2(0, height * i);

                    var rect = new Rect
                    {
                        position = rectPosition,
                        size = new Vector2(texture.width, height)
                    };

                    rects.Add(rect);
                }
            }

            var preview = new Rect
            {
                position = Vector2.zero,
                size = new Vector2(texture.width, texture.height)
            };

            rects.Add(preview);

            var rectCounter = 0;

            var spriteSheet = new SpriteMetaData[rects.Count];

            for (var i = 0; i < spriteSheet.Length; i++)
            {
                var data = new SpriteMetaData
                {
                    pivot = Vector2.down,
                    alignment = (int)SpriteAlignment.Center,
                    rect = rects[i],
                    name = fileName + "_" + rectCounter++
                };

                spriteSheet[i] = data;
            }

            textureImporter.spritesheet = spriteSheet;

            AssetDatabase.ForceReserializeAssets(new List<string> { assetPath });
            AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);

            int GetOrder(Sprite sprite)
            {
                var target = sprite.name.Replace($"{fileName}_", "");
                var order = int.Parse(target);

                return order;
            }

            var sprites = AssetDatabase.LoadAllAssetsAtPath(assetPath)
                .OfType<Sprite>()
                .OrderBy(GetOrder)
                .ToArray();

            asset.SetLevel0(PickRange(sprites, 0));
            asset.SetLevel1(PickRange(sprites, 1));
            asset.SetLevel2(PickRange(sprites, 2));
            asset.SetLevel3(PickRange(sprites, 3));

            asset.SetPreview(sprites[^1]);
            
            EditorUtility.SetDirty(asset);
        }

        private Sprite[] PickRange(Sprite[] sprites, int level)
        {
            switch (level)
            {
                case 0:
                {
                    var result = sprites[.._levelsSlices[0]];

                    return result.Reverse().ToArray();
                }
                case 1:
                {
                    var startIndex = _levelsSlices[0];
                    var endIndex = startIndex + _levelsSlices[1];

                    var result = sprites[startIndex..endIndex];

                    return result.Reverse().ToArray();
                }
                case 2:
                {
                    var startIndex = _levelsSlices[0] + _levelsSlices[1];
                    var endIndex = startIndex + _levelsSlices[2];

                    var result = sprites[startIndex..endIndex];

                    return result.Reverse().ToArray();
                }
                case 3:
                {
                    var startIndex = _levelsSlices[0] + _levelsSlices[1] + _levelsSlices[2];
                    var endIndex = startIndex + _levelsSlices[3];

                    var result = sprites[startIndex..endIndex];

                    return result.Reverse().ToArray();
                }
            }

            return null;
        }
    }
}