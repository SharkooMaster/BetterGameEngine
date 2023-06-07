using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGameEngine.MathB
{
    public class Matrix2x2 : Matrix
    {
        public List<float> floats = new List<float>();

        public Matrix2x2(float x = 0, float y = 0, float z = 0, float k = 0)
        {
            floats.Add(x);
            floats.Add(y);
            floats.Add(z);
            floats.Add(k);
        }

        public Vector2 getRow(int _row)
        {
            return (_row == 0) ? new Vector2(floats[0], floats[1]) : new Vector2(floats[2], floats[3]);
        }

        public Vector2 getCol(int _col)
        {
            return (_col == 0) ? new Vector2(floats[0], floats[2]) : new Vector2(floats[1], floats[3]);
        }

        public static Matrix2x2 operator- (Matrix2x2 left, Matrix2x2 right)
        {
            float _x = left.floats[0] - right.floats[0];
            float _y = left.floats[1] - right.floats[1];
            float _z = left.floats[2] - right.floats[2];
            float _k = left.floats[3] - right.floats[3];

            return new Matrix2x2(_x, _y, _z, _k);
        }

        public static Matrix2x2 operator- (Matrix2x2 left, float right)
        {
            float _x = left.floats[0] - right;
            float _y = left.floats[1] - right;
            float _z = left.floats[2] - right;
            float _k = left.floats[3] - right;

            return new Matrix2x2(_x, _y, _z, _k);
        }

        public static Matrix2x2 operator+ (Matrix2x2 left, Matrix2x2 right)
        {
            float _x = left.floats[0] + right.floats[0];
            float _y = left.floats[1] + right.floats[1];
            float _z = left.floats[2] + right.floats[2];
            float _k = left.floats[3] + right.floats[3];

            return new Matrix2x2(_x, _y, _z, _k);
        }

        public static Matrix2x2 operator+ (Matrix2x2 left, float right)
        {
            float _x = left.floats[0] + right;
            float _y = left.floats[1] + right;
            float _z = left.floats[2] + right;
            float _k = left.floats[3] + right;

            return new Matrix2x2(_x, _y, _z, _k);
        }

    }
}
