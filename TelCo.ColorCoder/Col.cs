using System;
using TelCo.ColorCoder;

namespace TelCo.ColorCoder
{
   class Col
    {
        public static CPair GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > CConstant.colorMapMinor.Length * CConstant.colorMapMajor.Length)
                throw new ArgumentOutOfRangeException(string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            int majorIndex = (pairNumber - 1) / CConstant.colorMapMinor.Length;
            int minorIndex = (pairNumber - 1) % CConstant.colorMapMinor.Length;

            CPair pair = new CPair() 
            {
                majorColor = CConstant.colorMapMajor[majorIndex],
                minorColor = CConstant.colorMapMinor[minorIndex]
            };
            return pair;
        }
        public static int GetPairNumberFromColor(CPair pair)
        {
            int majorIndex = -1, minorIndex = -1;
            for (int i = 0; i < CConstant.colorMapMajor.Length; i++)
                if (CConstant.colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            for (int i = 0; i < CConstant.colorMapMinor.Length; i++)
                if (CConstant.colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException(string.Format("Unknown Colors: {0}", pair.ToString()));
            return (majorIndex * CConstant.colorMapMinor.Length) + (minorIndex + 1);
        }
        public override string ToString() 
        {
            string colorCode = "";
            int i = 1;
            foreach(var majorColor in CConstant.colorMapMajor)
                foreach(var minorColor in CConstant.colorMapMinor)
                    colorCode +=$"MajorColor:{majorColor}, MinorColor:{minorColor}, PairNumber:{i++}\n";
            return colorCode;
        }
    }
}
