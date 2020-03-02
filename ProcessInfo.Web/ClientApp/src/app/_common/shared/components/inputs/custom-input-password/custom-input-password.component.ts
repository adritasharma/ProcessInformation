import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'input-password',
  templateUrl: './custom-input-password.component.html',
  styleUrls: ['./custom-input-password.component.css']
})
export class CustomInputPasswordComponent implements OnInit {

  @Input() model: any;
  @Input() label: string;
  @Input() fieldId: string;
  @Input() required: boolean;

  constructor() { }

  @Output() modelChange = new EventEmitter();
  @Output() blur = new EventEmitter();

  @ViewChild('modelRef') modelRef: NgModel;

  password;

  show = false;

  ngOnInit() {
    this.password = 'password';
  }

  onClick() {
    if (this.password === 'password') {
      this.password = 'text';
      this.show = true;
    } else {
      this.password = 'password';
      this.show = false;
    }
  }

  change(newValue) {
    if (newValue != null) {
      this.model = newValue;
      this.modelChange.emit(newValue);
    }
  }


}
