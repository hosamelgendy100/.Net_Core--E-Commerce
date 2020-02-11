// Modules 3rd party
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule, NG_VALIDATORS, FormControl } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { FlashMessagesModule } from 'angular2-flash-messages';

// Modules

// Routing
import { routing } from './app.routing';

// Services
import { HttpCommonService } from './shared/services/http-common.service';
import { requestOptionsService } from './shared/services/default-request-options.service';

// Main
import { AppComponent } from './app.component';

// Components
import { CategoryFormComponent } from './components/category/category-form.component';
import { CategoryListComponent } from './components/category/category-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CategoryFormComponent,
    CategoryListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, ReactiveFormsModule,
    HttpModule,
    JsonpModule,
    routing,
    FlashMessagesModule
  ],
  providers: [
    HttpCommonService,
    requestOptionsService
    ],
  bootstrap: [AppComponent]
})

export class AppModule {
}
