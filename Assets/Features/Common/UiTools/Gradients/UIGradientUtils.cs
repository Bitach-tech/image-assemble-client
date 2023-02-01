﻿using UnityEngine;

namespace Features.Common.UiTools.Gradients
{
    public static class UIGradientUtils
    {
        public static Vector2[] VerticePositions { get; } = { Vector2.up, Vector2.one, Vector2.right, Vector2.zero };

        public static Matrix2x3 LocalPositionMatrix(Rect rect, Vector2 dir)
        {
            var cos = dir.x;
            var sin = dir.y;
            var rectMin = rect.min;
            var rectSize = rect.size;
            var c = 0.5f;
            var ax = rectMin.x / rectSize.x + c;
            var ay = rectMin.y / rectSize.y + c;
            var m00 = cos / rectSize.x;
            var m01 = sin / rectSize.y;
            var m02 = -(ax * cos - ay * sin - c);
            var m10 = sin / rectSize.x;
            var m11 = cos / rectSize.y;
            var m12 = -(ax * sin + ay * cos - c);
            return new Matrix2x3(m00, m01, m02, m10, m11, m12);
        }

        public static Vector2 RotationDir(float angle)
        {
            var angleRad = angle * Mathf.Deg2Rad;
            var cos = Mathf.Cos(angleRad);
            var sin = Mathf.Sin(angleRad);
            return new Vector2(cos, sin);
        }

        public static Vector2 CompensateAspectRatio(Rect rect, Vector2 dir)
        {
            var ratio = rect.height / rect.width;
            dir.x *= ratio;
            return dir.normalized;
        }

        public static float InverseLerp(float a, float b, float v)
        {
            return a != b ? (v - a) / (b - a) : 0f;
        }

        public static Color Bilerp(Color a1, Color a2, Color b1, Color b2, Vector2 t)
        {
            var a = Color.LerpUnclamped(a1, a2, t.x);
            var b = Color.LerpUnclamped(b1, b2, t.x);
            return Color.LerpUnclamped(a, b, t.y);
        }

        public static void Lerp(UIVertex a, UIVertex b, float t, ref UIVertex c)
        {
            c.position = Vector3.LerpUnclamped(a.position, b.position, t);
            c.normal = Vector3.LerpUnclamped(a.normal, b.normal, t);
            c.color = Color32.LerpUnclamped(a.color, b.color, t);
            c.tangent = Vector3.LerpUnclamped(a.tangent, b.tangent, t);
            c.uv0 = Vector3.LerpUnclamped(a.uv0, b.uv0, t);
            c.uv1 = Vector3.LerpUnclamped(a.uv1, b.uv1, t);
            // c.uv2 = Vector3.LerpUnclamped(a.uv2, b.uv2, t);
            // c.uv3 = Vector3.LerpUnclamped(a.uv3, b.uv3, t);		
        }

        public struct Matrix2x3
        {
            public float m00, m01, m02, m10, m11, m12;

            public Matrix2x3(float m00, float m01, float m02, float m10, float m11, float m12)
            {
                this.m00 = m00;
                this.m01 = m01;
                this.m02 = m02;
                this.m10 = m10;
                this.m11 = m11;
                this.m12 = m12;
            }

            public static Vector2 operator *(Matrix2x3 m, Vector2 v)
            {
                var x = m.m00 * v.x - m.m01 * v.y + m.m02;
                var y = m.m10 * v.x + m.m11 * v.y + m.m12;
                return new Vector2(x, y);
            }
        }
    }
}