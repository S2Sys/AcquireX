using AcquireX.Core.Contracts;
using AcquireX.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcquireX.Core.Services
{
    public class DataSourceFactory
    {
        private readonly OAuthService _oauthService;

        public DataSourceFactory(OAuthService oauthService)
        {
            _oauthService = oauthService;
        }

        public IDataSource CreateDataSource(DataSourceType dataSourceType, string baseUrl)
        {
            switch (dataSourceType)
            {
                case DataSourceType.Banner:
                    return new BannerDataSource(_oauthService, baseUrl);
                case DataSourceType.RSHughes:
                    return new RSHughesDataSource(_oauthService, baseUrl);
                default:
                    throw new ArgumentException($"Unsupported data source type: {dataSourceType}");
            }
        }
    }
}
