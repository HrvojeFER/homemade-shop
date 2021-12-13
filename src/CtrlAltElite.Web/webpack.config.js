// const path = require('path');

// module.exports = {
//   entry: ['./Typescript/site.ts'],
//   devtool: 'inline-source-map',
//   module: {
//     rules: [
//       {
//         test: /\.ts$/,
//         use: 'ts-loader',
//         exclude: /node_modules/
//       }
//     ]
//   },
//   resolve: {
//     extensions: [ '.ts', '.js' ]
//   },
//   output: {
//     filename: 'site.js',
//     path: path.resolve(__dirname, 'wwwroot/js')
//   }
// };
/*********************************
* Environment and imports
*********************************/
const environment = process.env.NODE_ENV || "development";
const path = require("path");

var glob = require("glob");
const webpack = require("webpack");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const FixDefaultImportPlugin = require('webpack-fix-default-import-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
require('imports-loader');

const entry = {
    "../wwwroot/js/site.js": path.resolve(__dirname, "Typescript/site.ts"),
    "../wwwroot/js/loginReg.js": path.resolve(__dirname, "Typescript/loginReg.ts"),
    "../wwwroot/js/styles.js": path.resolve(__dirname, "Scss/Site.scss")
};

const plugins = [
    // new ExtractTextPlugin({
    //     filename: "[name]",
    //     disable: false,
    //     allChunks: false
    // })
    // new webpack.DefinePlugin({
    //     "process.env": {
    //         "NODE_ENV": JSON.stringify(process.env.NODE_ENV)
    //     }
    // }),
    // new webpack.ProvidePlugin({
    //     "$": "jquery",
    //     "jQuery": "jquery",
    //     "window.jQuery": "jquery"
    // }),
    // new FixDefaultImportPlugin(),
    // new MiniCssExtractPlugin({
    //     // Options similar to the same options in webpackOptions.output
    //     // both options are optional
    //     filename: "[name]",
    //     chunkFilename: "[id].css"
    //   })
];

/*********************************
* Exports
*********************************/

module.exports  = {
    output: { filename: '[name]' },
    entry: entry,
    plugins: plugins,
    module: {
      rules: [
        {
          test: /\.ts$/,
          use: 'ts-loader',
          exclude: /node_modules/
        }, {
            test: /\.scss$|\.css$/,
            use: [
                "style-loader",
                "css-loader",
                "sass-loader",
            ],
            exclude: /node_modules/
        }, {
            test: /\.woff2?$|\.ttf$|\.eot$|\.svg$/,
            use: [{
                loader: "file-loader"
            }],
            exclude: /node_modules/
        }
    ]
  }
}