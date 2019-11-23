import { Directive, OnInit } from '@angular/core';
import { NgControl, NgForm, NgModel } from "@angular/forms";

@Directive({
    selector: '[ChildFieldControl]',
    providers: [NgModel]
})
export class ChildFieldControlDirective implements OnInit {

    constructor(private form: NgForm, private eltControl: NgControl) {
    }

    ngOnInit() {
        setTimeout(() => {
            if (this.form && this.eltControl) {
                this.form.form.addControl(this.eltControl.name, this.eltControl.control);
            }
        }, 1);
    }

}