import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CategoryFormComponent } from './components/category/category-form.component';
import { CategoryListComponent } from './components/category/category-list.component';

export const routes: Routes = [
    { path: 'category', component: CategoryFormComponent }, 
    { path: 'category/:id', component: CategoryFormComponent },
    { path: 'categories', component: CategoryListComponent }, 
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
