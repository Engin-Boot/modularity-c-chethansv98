using System;

namespace TelCo.ColorCoder
{
   class Col
    {
        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > ColorCodeConstant.colorMapMinor.Length * ColorCodeConstant.colorMapMajor.Length)
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            int majorIndex = (pairNumber - 1) / ColorCodeConstant.colorMapMinor.Length;
            int minorIndex = (pairNumber - 1) % ColorCodeConstant.colorMapMinor.Length;

            ColorPair pair = new ColorPair() 
            {
                majorColor = ColorCodeConstant.colorMapMajor[majorIndex],
                minorColor = ColorCodeConstant.colorMapMinor[minorIndex]
            };
            return pair;
        }
        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = -1, minorIndex = -1;
            for (int i = 0; i < ColorCodeConstant.colorMapMajor.Length; i++)
                if (ColorCodeConstant.colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            for (int i = 0; i < ColorCodeConstant.colorMapMinor.Length; i++)
                if (ColorCodeConstant.colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            return (majorIndex * ColorCodeConstant.colorMapMinor.Length) + (minorIndex + 1);
        }
        public override string ToString() 
        {
            string colorCode = "";
            int i = 1;
            foreach(var majorColor in ColorCodeConstant.colorMapMajor)
                foreach(var minorColor in ColorCodeConstant.colorMapMinor)
                    colorCode +=$"MajorColor:{majorColor}, MinorColor:{minorColor}, PairNumber:{i++}\n";
            return colorCode;
        }
    }
}