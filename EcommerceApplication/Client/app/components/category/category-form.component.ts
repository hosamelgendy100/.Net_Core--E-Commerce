import { Component, OnDestroy, OnInit } from '@angular/core';
import { FlashMessagesService } from 'angular2-flash-messages';
import { ActivatedRoute } from '@angular/router';
import { HttpCommonService } from '../../shared/services/http-common.service';


@Component({
    //moduleId: module.id,
    selector: 'app-category-form',
    templateUrl: 'category-form.component.html',
    styleUrls: ['category-form.component.css']
})
export class CategoryFormComponent {
    public apiName: string
    protected model = {};
    protected submitted = false;
    private sub: any;
    id: number;

    constructor(private _httpCommonService: HttpCommonService,
        private flashMessagesService: FlashMessagesService,
        private route: ActivatedRoute) {
        this.apiName = "admin/categoryNg";
        this.sub = route.params.subscribe(params => {
            this.id = +params['id']; 
            if (this.id > 0) {
                _httpCommonService.getItem(this.apiName + "/get", this.id).subscribe(
                    data => {
                        this.model = data;
                    },
                    err => {
                        this.showError(err);
                    });
            }

        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    reset() {
        this.id = 0;
        this.model = {};

    }
    save() {
        if (this.id > 0) {
            this._httpCommonService.update(this.apiName + "/update", this.model).subscribe(
                data => {
                    this.showSuccess("updated");
                },
                err => {
                    this.showError(err);
                });
        }
        else {
            this._httpCommonService.create(this.apiName + "/create", this.model).subscribe(
                data => {
                    this.showSuccess("created");
                },
                err => {
                    this.showError(err);
                });
        }

    }
    showError(err: any) {
        this.flashMessagesService.show(err, { cssClass: 'alert-danger' });
        this.submitted = false;
    }

    showSuccess(msg: any) {
        this.flashMessagesService.show(msg, { cssClass: 'alert-success' });
        this.submitted = true;
    }
    delete() {
        this._httpCommonService.delete(this.apiName + "/delete", this.model["id"]).subscribe(
            data => {
                this.showSuccess("deleted");
            },
            err => {
                this.showError(err);
            });;
    }
}
