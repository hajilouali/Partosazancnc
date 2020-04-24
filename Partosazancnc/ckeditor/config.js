/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.contentsLangDirection = 'rtl';
    config.language = 'fa';

    config.filebrowserImageUploadUrl = '/Home/UploadImage';
    config.allowedContent = true;
    config.removeFormatAttributes = '';
    config.contentsCss = ['/assets/plugins/bootstrap/css/bootstrap.min.css', '/assets/css/layout.css', '/assets/css/essentials.css', '/assets/plugins/bootstrap/RTL/bootstrap-rtl.min.css', '/assets/css/layout-RTL.css','/assets/css/color_scheme/green.css'];


 //   config.toolbar =
 //[
 //  [
 //    'SourceBold',
 //    'Italic',
 //    'Underline',
 //    'Strike',
 //    '-',
 //    'Subscript',
 //    'SuperscriptNumberedList',
 //    'BulletedList',
 //    '-',
 //    'Outdent',
 //    'Indent/Styles',
 //    'Format',
 //    'Font',
 //    'FontSize',
 //    'Image'

 //  ]
 //];
};
