using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampDocManager;
using VampirioCode.UI;
using VampirioCode.Builder.Simple;

namespace VampirioCode.Builder
{
    public class Builders
    {

        private static Dictionary<DocumentType, List<Builder>> builders;
        private static Dictionary<DocumentType, List<BuilderType>> builderTypes;
        private static Dictionary<BuilderType, Builder> allBuilders;

        public static void Initialize()
        {
            builders =      new Dictionary<DocumentType, List<Builder>>();
            builderTypes =  new Dictionary<DocumentType, List<BuilderType>>();
            allBuilders =   new Dictionary<BuilderType, Builder>();

            _Register(DocumentType.CSHARP,      new SimpleCSharpBuilder());
            _Register(DocumentType.CPP,         new SimpleMsvcCppBuilder());
            _Register(DocumentType.CPP,         new SimpleGnuCppWSLBuilder());
            _Register(DocumentType.CPP,         new SimpleClangCppBuilder());
            _Register(DocumentType.CPP,         new SimpleWasmCppBuilder());
            _Register(DocumentType.JS,          new SimpleJsBuilder());
            _Register(DocumentType.JAVA,        new SimpleJavaBuilder());
            _Register(DocumentType.PHP,         new SimplePhpBuilder());

        }

        private static void _Register(DocumentType docType, Builder builder)
        {
            if (builders.ContainsKey(docType))
            {
                builders[docType].Add(builder);
                builderTypes[docType].Add(builder.Type);
            }
            else
            {
                builders.Add(docType, new Builder[] { builder }.ToList());
                builderTypes.Add(docType, new BuilderType[] { builder.Type }.ToList());
            }

            allBuilders.Add(builder.Type, builder);
        }

        /// <summary>
        /// Get the default builder type for a language. 
        /// For example: if the document was recently opened or if the user change the document type from
        /// the top of the application. He select C++ for example. Then there are 2 C++ builders, so this
        /// method will return a default builder type for that language.
        /// </summary>
        public static BuilderType GetDefaultTypeFor(DocumentType docType)
        {
            return GetBuilderypesFor(docType)[0];
        }

        public static BuilderType[] GetBuilderypesFor(DocumentType docType) 
        {
            if (builderTypes.ContainsKey(docType))
                return builderTypes[docType].ToArray();
            else
                return new BuilderType[] { BuilderType.None };
        }

        // return all builders for any languages
        public static BuilderType[] GetBuilderTypes()
        {
            return builders.SelectMany(pair => pair.Value).Select(builder => builder.Type).ToArray();
        }

        public static Builder GetBuilder(BuilderType type)
        {
            if (allBuilders.ContainsKey(type))
                return allBuilders[type];
            else
                return null;
        }

        public static Builder[] GetBuilders()
        {
            return allBuilders.Select(pair => pair.Value).ToArray();
        }

        public static ToolStripMenuItem[] CreateMenuItems()
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            Builder[] builders = GetBuilders();

            foreach (Builder builder in builders)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(builder.Name);
                item.Tag = builder.Type;
                items.Add(item);
            }

            return items.ToArray();
        }

    }
}
