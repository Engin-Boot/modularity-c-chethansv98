using System;
using TelCo.ColorCoder;

namespace TelCo.ColorCoder
{
   class Color
    {
        public static Pair GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > ColorConstant.colorMapMinor.Length * ColorConstant.colorMapMajor.Length)
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            int majorIndex = (pairNumber - 1) / ColorConstant.colorMapMinor.Length;
            int minorIndex = (pairNumber - 1) % ColorConstant.colorMapMinor.Length;

            Pair pair = new Pair() 
            {
                majorColor = ColorConstant.colorMapMajor[majorIndex],
                minorColor = ColorConstant.colorMapMinor[minorIndex]
            };
            return pair;
        }
        public static int GetPairNumberFromColor(Pair pair)
        {
            int majorIndex = -1, minorIndex = -1;
            for (int i = 0; i < ColorConstant.colorMapMajor.Length; i++)
                if (ColorConstant.colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            for (int i = 0; i < ColorConstant.colorMapMinor.Length; i++)
                if (ColorConstant.colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            return (majorIndex * ColorConstant.colorMapMinor.Length) + (minorIndex + 1);
        }
        public override string ToString() 
        {
            string colorCode = "";
            int i = 1;
            foreach(var majorColor in ColorConstant.colorMapMajor)
                foreach(var minorColor in ColorConstant.colorMapMinor)
                    colorCode +=$"MajorColor:{majorColor}, MinorColor:{minorColor}, PairNumber:{i++}\n";
            return colorCode;
        }
    }
}
