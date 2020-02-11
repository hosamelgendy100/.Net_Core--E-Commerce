import { Component } from '@angular/core';
import { HttpCommonService } from '../../shared/services/http-common.service';
import { ActivatedRoute } from '@angular/router';
import { FlashMessagesService } from 'angular2-flash-messages';

@Component({
    //moduleId: module.id,
    selector: 'app-category-list',
    templateUrl: 'category-list.component.html',
    styleUrls: ['category-list.component.css']
})
export class CategoryListComponent {
    public apiName: string
    public items: any;
    private sub: any;
    id: number;

    constructor(private _httpCommonService: HttpCommonService,
        private flashMessagesService: FlashMessagesService,
        private route: ActivatedRoute) {
        this.apiName = "admin/categoryNg";
        this.sub = route.params.subscribe(params => {
            _httpCommonService.getList(this.apiName + "/GetAll").subscribe(data => {
                this.items = data
            });
        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}
