using System.Xml.Serialization;

namespace HudLibFontGen
{
    public struct Vector2
    {
        public float X;
        public float Y;

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2() { X = a.X + b.X, Y = a.Y + b.Y };
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2() { X = a.X - b.X, Y = a.Y - b.Y };
        }
    }

    /// <summary>
    /// Type used to store deserialized XML font data.
    /// </summary>
    [XmlType("font")]
    public class BmGenData
    {
        [XmlAttribute("base")]
        public float baseline;
        [XmlAttribute]
        public float height;
        [XmlAttribute("face")]
        public string faceName;
        /// <summary>
        /// Size of the font in points
        /// </summary>
        [XmlAttribute("size")]
        public float ptSize;
        [XmlAttribute]
        public string style;

        /// <summary>
        /// Texture atlases used to render the characters
        /// </summary>
        [XmlArray("bitmaps")]
        public BitmapData[] bitmaps;
        [XmlArray("glyphs")]
        public GlyphData[] glyphs;
        [XmlArray("kernpairs")]
        public KerningPairData[] kernPairs;

        /// <summary>
        /// Converts a string representing a 2D vector whose elements are separated by an 'x' or ',' into
        /// a <see cref="Vector2"/>.
        /// </summary>
        public static Vector2 ParseVector(string value)
        {
            string[] members = value.Split('x', ',');

            return new Vector2()
            {
                X = float.Parse(members[0]),
                Y = float.Parse(members[1])
            };
        }
    }

    [XmlType("bitmap")]
    public class BitmapData
    {
        [XmlAttribute]
        public int id;
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public string size;
    }

    [XmlType("glyph")]
    public class GlyphData
    {
        /// <summary>
        /// Glyph char value
        /// </summary>
        [XmlAttribute]
        public string ch;
        /// <summary>
        /// Bitmap ID
        /// </summary>
        [XmlAttribute("bm")]
        public int bitmapID;
        /// <summary>
        /// Offset from texture origin
        /// </summary>
        [XmlAttribute]
        public string origin;
        /// <summary>
        /// Dimensions
        /// </summary>
        [XmlAttribute]
        public string size;
        /// <summary>
        /// Advance Width
        /// </summary>
        [XmlAttribute("aw")]
        public float advanceWidth;
        /// <summary>
        /// Left Side Bearing
        /// </summary>
        [XmlAttribute("lsb")]
        public float leftSideBearing;
    }

    /// <summary>
    /// Stores data needed adjusting the spacing between a given character pair for a given font.
    /// </summary>
    [XmlType("kernpair")]
    public class KerningPairData
    {
        [XmlAttribute]
        public string left;
        [XmlAttribute]
        public string right;
        [XmlAttribute]
        public float adjust;
    }
}