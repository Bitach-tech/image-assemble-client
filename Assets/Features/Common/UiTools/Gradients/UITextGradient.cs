﻿using UnityEngine;
using UnityEngine.UI;

namespace Features.Common.UiTools.Gradients
{
    [AddComponentMenu("UI/Effects/Text Gradient")]
    public class UITextGradient : BaseMeshEffect
    {
        public Color m_color1 = Color.white;
        public Color m_color2 = Color.white;
        [Range(-180f, 180f)] public float m_angle = 0f;

        public override void ModifyMesh(VertexHelper vh)
        {
            if (enabled)
            {
                var rect = graphic.rectTransform.rect;
                var dir = UIGradientUtils.RotationDir(m_angle);
                var localPositionMatrix = UIGradientUtils.LocalPositionMatrix(new Rect(0f, 0f, 1f, 1f), dir);

                var vertex = default(UIVertex);
                for (var i = 0; i < vh.currentVertCount; i++)
                {
                    vh.PopulateUIVertex(ref vertex, i);
                    var position = UIGradientUtils.VerticePositions[i % 4];
                    var localPosition = localPositionMatrix * position;
                    vertex.color *= Color.Lerp(m_color2, m_color1, localPosition.y);
                    vh.SetUIVertex(vertex, i);
                }
            }
        }
    }
}