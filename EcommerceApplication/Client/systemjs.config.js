(function (global) {
    System.config({
        paths: {
            
            'npm:': 'node_modules/'
        },
        
        map: {
            app: 'app',

            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/compiler-cli': 'npm:@angular/compiler/bundles/compiler-cli.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            'angular2-flash-messages': 'npm:angular2-flash-messages',
            'angular2-datatable': 'npm:angular2-datatable',
            'lodash': 'npm:lodash',
            'angular2-moment': 'npm:angular2-moment',
            'moment': 'npm:moment',
            'ng2-slimscroll': 'npm:ng2-slimscroll',
            'ng2-datepicker': 'npm:ng2-datepicker',
            'ng2-file-upload': 'npm:ng2-file-upload',
            'rxjs': 'npm:rxjs',
            'angular-in-memory-web-api': 'npm:angular-in-memory-web-api/bundles/in-memory-web-api.umd.js'
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: {
                main: './main.js',
                defaultExtension: 'js'
            },
            rxjs: {
                defaultExtension: 'js'
            },
            'angular2-flash-messages': { main: 'index.js', defaultExtension: 'js' },

            'angular2-datatable': { main: 'index.js', defaultExtension: 'js' },


            'ng2-file-upload': { defaultExtension: 'js' },

            'angular2-moment': {
                main: 'index.js',
                defaultExtension: 'js'
            },
            'moment': {
                main: 'moment.js',
                defaultExtension: 'js'
            },
            'ng2-slimscroll': {
                main: 'ng2-slimscroll.js',
                defaultExtension: 'js'
            },
            'ng2-datepicker': {
                // format: 'register',
                main: 'ng2-datepicker.js',
                defaultExtension: 'js'
            },
            'lodash': { main: 'index.js', defaultExtension: 'js' },

            'angular2-messages': { main: 'angular2-messages.js', defaultExtension: 'js' }

        }
    });
})(this);
