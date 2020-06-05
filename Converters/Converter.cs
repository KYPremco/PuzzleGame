using Newtonsoft.Json;
using PuzzleGame.Encoded;
using System.Collections.Generic;

namespace PuzzleGame.Converters
{
    public static class Converter
    {
        /// <summary>
        /// Returns List<string>
        /// </summary>
        /// <param name="Json list"></param>
        /// <returns></returns>
        public static List<string> DeserializeLevelList(string list)
        {
            return JsonConvert.DeserializeObject<List<string>>(list);
        }
    }

    public static class GridConverter
    {
        /// <summary>
        /// Returns grid
        /// </summary>
        /// <param name="EncodedGrid"></param>
        /// <returns></returns>
        public static GridStruct DeserializeGrid(string EncodedGrid)
        {
            return JsonConvert.DeserializeObject<EncodedGridStruct>(EncodedGrid).DecodeGrid();
        }

        /// <summary>
        /// Returns json string
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static string Serialize(this GridStruct grid)
        {
            return JsonConvert.SerializeObject(grid.Encode(), Formatting.Indented);
        }
    }
}
