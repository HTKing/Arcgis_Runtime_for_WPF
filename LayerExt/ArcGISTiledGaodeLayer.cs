using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace runtime1207
{
    
    public class ArcGISTiledGaodeLayer : TiledMapServiceLayer
    {

        public string layerType
        {
            get { return (string)GetValue(layerTypeProperty); }
            set { SetValue(layerTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for layerType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty layerTypeProperty =
            DependencyProperty.Register("layerType", typeof(string), typeof(ArcGISTiledGaodeLayer), new PropertyMetadata("road"));

     
        public ArcGISTiledGaodeLayer()
        {
            this.SpatialReference = new SpatialReference(3857);

            this.FullExtent = new Envelope(-20037508.342787, -20037508.342787, 20037508.342787, 20037508.342787);
            Lod[] lods = {
                new Lod() { Resolution = 156543.033928 },
                new Lod() { Resolution = 78271.5169639999 },
                new Lod() { Resolution = 39135.7584820001 },
                new Lod() { Resolution = 19567.8792409999 },
                new Lod() { Resolution = 9783.93962049996 },
                new Lod() { Resolution = 4891.96981024998 },
                new Lod() { Resolution = 2445.98490512499 },
                new Lod() { Resolution = 1222.99245256249 },
                new Lod() { Resolution = 611.49622628138 },
                new Lod() { Resolution = 305.748113140558 },
                new Lod() { Resolution = 152.874056570411 },
                new Lod() { Resolution = 76.4370282850732 },
                new Lod() { Resolution = 38.2185141425366 },
                new Lod() { Resolution = 19.1092570712683 },
                new Lod() { Resolution = 9.55462853563415 },
                new Lod() { Resolution = 4.77731426794937 },
                new Lod() { Resolution = 2.38865713397468 },
                new Lod() { Resolution = 1.19432856685505 },
                new Lod() { Resolution = 0.597164283559817 },
                new Lod() { Resolution = 0.298582141647617 }};
            this.TileInfo = new TileInfo()
            {
                Height = 256,
                Width = 256,

                Origin = new MapPoint(-20037508.342787, 20037508.342787, this.SpatialReference),

                Lods = lods
            };
        }
        public override string GetTileUrl(int level, int row, int col)
        {
            var url = "";
            switch (this.layerType)
            {
                case "road":
                    url ="http://webrd0" + (col % 4 + 1) +".is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=8&x=" + col +"&y=" + row +"&z=" + level;
                    break;
                case "st":
                    url ="http://webst0" + (col % 4 + 1) +".is.autonavi.com/appmaptile?style=6&x=" + col +"&y=" + row +"&z=" + level;
                    break;
                case "label":
                    url ="http://webst0" + (col % 4 + 1) +".is.autonavi.com/appmaptile?style=8&x=" + col +"&y=" + row +"&z=" + level;
                    break;
                default:
                    url ="http://webrd0" + (col % 4 + 1) +".is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=8&x=" + col +"&y=" + row +"&z=" + level;
                    break;
            }
            return url;
        }
    }

}
