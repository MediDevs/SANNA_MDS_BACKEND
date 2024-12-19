using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Infrastructure.Settings
{
    public interface IDocumentSettings
    {
        public string BaseFolder { get; }
        public string ArticleDocumentsFolder { get; }
        public string WordTemplatesFolder { get; }
    }
}
