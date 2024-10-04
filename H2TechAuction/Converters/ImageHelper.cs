using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.Converters;

public static class ImageHelper
{
    public static Bitmap LoadFromResource(Uri resourceUri)=> new (AssetLoader.Open(resourceUri));
    
}