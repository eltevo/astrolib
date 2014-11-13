using System;
using System.Text;
using System.Globalization;

namespace Jhu.AstroLib.Coord
{
    public class DegreeFormatInfo
    {
        #region Static properties

        public static DegreeFormatInfo DefaultHours
        {
            get
            {
                return new DegreeFormatInfo()
                {
                    degreeStyle = Coord.DegreeStyle.Hours,
                    increment = 0.15 / 3600.0,
                    numberFormatString = ".00",
                    hourSymbol = ":",
                    minuteSymbol = ":",
                    secondSymbol = "",
                };
            }
        }

        public static DegreeFormatInfo DefaultDegrees
        {
            get
            {
                return new DegreeFormatInfo()
                {
                    degreeStyle = Coord.DegreeStyle.Symbols,
                    increment = 0.01 / 3600.0,
                    numberFormatString = ".00",
                    degreeSymbol = ":",
                    arcMinuteSymbol = ":",
                    arcSecondSymbol = "",
                };
            }
        }

        #endregion
        #region Property storage variables

        private NumberFormatInfo numberFormat;
        private string numberFormatString;
        private DegreeStyle degreeStyle;
        private DegreeWrapAroundStyle degreeWrapAroundStyle;
        private bool leadingPositiveSign;
        private string positiveSign;
        private string negativeSign;
        private string figureSpace;
        private string degreeSymbol;
        private string arcMinuteSymbol;
        private string arcSecondSymbol;
        private string hourSymbol;
        private string minuteSymbol;
        private string secondSymbol;
        private double increment;

        #endregion
        #region Properties

        public NumberFormatInfo NumberFormat
        {
            get { return numberFormat; }
            set { numberFormat = value; }

        }
        public string NumberFormatString
        {
            get { return numberFormatString; }
            set { numberFormatString = value; }
        }

        public DegreeStyle DegreeStyle
        {
            get { return degreeStyle; }
            set { degreeStyle = value; }
        }

        public DegreeWrapAroundStyle DegreeWrapAroundStyle
        {
            get { return degreeWrapAroundStyle; }
            set { degreeWrapAroundStyle = value; }
        }

        public bool LeadingPositiveSign
        {
            get { return leadingPositiveSign; }
            set { leadingPositiveSign = value; }
        }

        public string PositiveSign
        {
            get { return positiveSign; }
            set { positiveSign = value; }
        }

        public string NegativeSign
        {
            get { return negativeSign; }
            set { negativeSign = value; }
        }

        public string FigureSpace
        {
            get { return figureSpace; }
            set { figureSpace = value; }
        }

        public string DegreeSymbol
        {
            get { return degreeSymbol; }
            set { degreeSymbol = value; }
        }

        public string ArcMinuteSymbol
        {
            get { return arcMinuteSymbol; }
            set { arcMinuteSymbol = value; }
        }

        public string ArcSecondSymbol
        {
            get { return arcSecondSymbol; }
            set { arcSecondSymbol = value; }
        }

        public string HourSymbol
        {
            get { return hourSymbol; }
            set { hourSymbol = value; }
        }

        public string MinuteSymbol
        {
            get { return minuteSymbol; }
            set { minuteSymbol = value; }
        }

        public string SecondSymbol
        {
            get { return secondSymbol; }
            set { secondSymbol = value; }
        }

        public double Increment
        {
            get { return increment; }
            set { increment = value; }
        }

        #endregion
        #region Constructors and initializer

        public DegreeFormatInfo()
        {
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            this.numberFormat = CultureInfo.InvariantCulture.NumberFormat;
            this.numberFormatString = "n";
            this.degreeStyle = DegreeStyle.Decimal;
            this.degreeWrapAroundStyle = DegreeWrapAroundStyle.PlusMinus180;
            this.leadingPositiveSign = false;

            /*
            // not so nice ASCII symbols
            this.negativeSign = "-";
            this.positiveSign = "+";
            this.figureSpace = " ";
            this.degreeSymbol = "\u00B0";
            this.arcMinuteSymbol = "'";
            this.arcSecondSymbol = "\"";
            this.hourSymbol = "h";
            this.minuteSymbol = "m";
            this.secondSymbol = "s";
            */

            // nice unicode symbols
            this.negativeSign = "\u2212";       // figure dash
            this.positiveSign = "+";
            this.figureSpace = "\u2007";        // figure space
            this.degreeSymbol = "\u00B0";
            this.arcMinuteSymbol = "\u2032";    // prime
            this.arcSecondSymbol = "\u2033";    // double prime
            this.hourSymbol = "\u02B0";         // superscript h
            this.minuteSymbol = "\u1D50";       // superscript m
            this.secondSymbol = "\u02E2";       // superscript s
            this.increment = 1;                 // increment id degrees
        }

        #endregion
    }
}
