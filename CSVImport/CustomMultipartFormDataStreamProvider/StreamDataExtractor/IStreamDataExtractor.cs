using System.IO;
using System.Threading.Tasks;

namespace CustomMultipartFormDataStreamProvider.StreamDataExtractor
{
    public interface IStreamDataExtractor
    {
        Task<bool> ExtractDataFromStream(Stream stream);
    }
}