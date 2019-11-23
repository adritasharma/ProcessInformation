import { Component, OnInit, SimpleChanges, Input, AfterViewInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'input-text',
  templateUrl: './custom-input-text.component.html',
  styleUrls: ['./custom-input-text.component.css']
})
export class CustomInputTextComponent implements OnInit, AfterViewInit {

  constructor() { }

  @Input() model: any;
  @Input() label: string;
  @Input() fieldId: string;
  @Input() required: boolean;
  @Input() isCapital: boolean;
  @Input() pattern: any
  @Input() invalidMsg: string
  @Input() disabled: boolean;
  @Input() patternType: string // using patternType will override pattern and invalidMsg
  @Input() maxLength: number
  @Input() focus: boolean
  @Input() isTextArea: boolean
  lengthErrorMessage: string;

  @Output() modelChange = new EventEmitter();

  @ViewChild('modelRef') modelRef: NgModel;

  patternMessage: any = [
    {
      type: "mobile",
      message: "Input Should be 10 Digit Number"
    },
    {
      type: "email",
      message: "Input Format Should be abc@xyz.eg"
    },
    {
      type: "alphabet",
      message: "Input Should be Only Alphabets"
    }
  ]

  ngOnInit() {
    if (this.patternType != undefined) {
      switch (this.patternType) {
        case "alphabet":
          this.pattern = '[a-zA-Z\s]+$';
          this.invalidMsg = "Input Should be Only Alphabets";
          break;

        case "email":
          this.pattern = '[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$';
          this.invalidMsg = "Input Format Should be abc@xyz.eg"
          break;
        case "mobile":
          this.maxLength = 10;
          this.pattern = '^[0-9]{10}$';
          this.invalidMsg = "Input Should be 10 Digit Number";
          break;

        case "numeric":
          this.pattern = '^[0-9]*$';
          this.invalidMsg = "Input Should be Number"
          break;

        case "pincode":
          this.maxLength = 6;
          this.pattern = '^[0-9]{6}$';
          this.invalidMsg = "Input Should be 6 Digit Number";
          break;

        case "email":
          this.pattern = '[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$';
          this.invalidMsg = "email invalid"
          break;
      }
    }
  }

  ngAfterViewInit() {
   
  }

  change(newValue) {
    if (newValue != null) {
      var stringLength: number = newValue.length

      if (!newValue.replace(/\s/g, '').length) {
        if (stringLength > 1) {
          this.invalidMsg = `Please enter any character`
          this.modelRef.control.setErrors({ 'invalid': true })
        }
      }
      if (newValue != null) {
        newValue = newValue.trim();
      }

      if (newValue == "") {
        if (this.required == true) {
          if (stringLength < 1) {
            this.invalidMsg = "Required"
          } else {
            this.invalidMsg = `Please enter any character`
          }
          this.modelRef.control.setErrors({ 'invalid': true })
        } else {
          this.setDefaultPatternMsg()
        }
      } else {

        if (this.maxLength != undefined) {
          if (newValue.length >= this.maxLength) {
            this.lengthErrorMessage = `Maximum Allowed Length is ${this.maxLength}`
            //this.currentModel.control.setErrors({ 'invalid': true })
          } else {
            this.lengthErrorMessage = undefined
            this.setDefaultPatternMsg()
          }
        }
        this.setDefaultPatternMsg()
      }
      this.model = newValue;
      this.modelChange.emit(newValue);
    }
  }

  setDefaultPatternMsg() {
    if (this.patternType != null) {
      var invalidData = this.patternMessage.filter(x => x.type == this.patternType)
      if (invalidData.length > 0) {
        this.invalidMsg = invalidData[0].message
      }
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    this.fieldId = this.label.replace(/\s/g,'');
    if (this.focus == true && this.fieldId) {
      console.log('f',this.fieldId)
      // document.getElementById(this.fieldId).focus();
    }
    if (changes['model']) {
      if (this.model != undefined && this.model != '') {
        this.model = this.model[0].toUpperCase() + this.model.slice(1)
      }
      if (this.model != undefined && this.model != '' && this.isCapital == true) {
        this.model = this.model.toUpperCase()
      }
    }
  }
}