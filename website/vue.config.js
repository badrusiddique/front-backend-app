module.exports = {
  lintOnSave: false,
  runtimeCompiler: true,
  productionSourceMap: false,
  configureWebpack: {
    devtool: 'eval-source-map',
  },
  devServer: {
    proxy: {
      '/api': {
        https: true,
        target: 'https://localhost:8086', // target API host
        changeOrigin: true, // needed for virtual hosted sites
      },
    },
    headers: {
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept',
    },
  },
  pluginOptions: {
    webpackBundleAnalyzer: {
      openAnalyzer: false,
      analyzerMode: 'disabled',
    },
    jestSerializer: {
      stringifyObjects: true,
    },
    compression: {
      gzip: {
        minRatio: 0.8,
        algorithm: 'gzip',
        filename: '[path].gz[query]',
        include: /\.(js|css|html|svg|json)(\?.*)?$/i,
      },
    },
  },
  css: {
    extract: false,
    loaderOptions: {
      scss: {},
    },
  },
};
