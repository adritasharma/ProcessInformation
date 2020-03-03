import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'input-radio',
  templateUrl: './custom-input-radio.component.html',
  styleUrls: ['./custom-input-radio.component.css']
})
export class CustomInputRadioComponent implements OnInit {

  constructor() { }

  @Input() itemList: any
  @Input() model: any;
  @Input() label: string;
  @Input() id: string;
  @Input() required: boolean;
  @Input() disabled: boolean;

  @Output() modelChange = new EventEmitter();

  ngOnInit() {
    if (this.required && !this.model) {
      this.model = this.itemList[0].value;
    }
  }

  change() {
    this.modelChange.emit(this.model);
  }

}
