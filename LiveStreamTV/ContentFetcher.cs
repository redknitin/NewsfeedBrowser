using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;

namespace LiveStreamTV
{
    class ContentFetcher
    {
        public List<string> Feeds { get; set; }

        public ContentFetcher()
        {
            var lstFeeds = new List<string>();
            lstFeeds.Add("http://www.radhagopinathmedia.com/feeds/posts/default?alt=rss");
            Feeds = lstFeeds;
        }
        public ContentFetcher(List<string> aFeeds) { Feeds = aFeeds; }

        public List<SyndicationItem> GoFetch()
        {
            List<SyndicationItem> lstItems = new List<SyndicationItem>();
            foreach (var iterFeed in Feeds)
            {
                var rssReader = XmlReader.Create(iterFeed);
                var synFeed = SyndicationFeed.Load(rssReader);
                lstItems.AddRange(synFeed.Items);
            }
            return lstItems;
        }
    }
}
