import { Component, OnInit, Input, Output, EventEmitter, SimpleChanges } from '@angular/core';

@Component({
  selector: 'input-select',
  templateUrl: './custom-input-select.component.html',
  styleUrls: ['./custom-input-select.component.css']
})
export class CustomInputSelectComponent implements OnInit {

  constructor() { }

  @Input() dropdownValues: any
  @Input() model: any;
  @Input() label: string;
  @Input() fieldId: string;
  @Input() required: boolean;
  @Input() disabled: boolean;

  @Output() modelChange = new EventEmitter();


  ngOnInit() {

    if ((this.dropdownValues.filter(x => x.id == null) < 1)) {
      this.dropdownValues.unshift(
        {
          id: null,
          text: `  -- Select ${this.label} --`
        }
      )
    }
  }

  change(newValue) {
    if (newValue != null) {
      this.model = newValue;
      this.modelChange.emit(newValue);
    }
  }
  ngOnChanges(changes: SimpleChanges) {
    if (changes.dropdownValues) {
      this.dropdownValues = changes.dropdownValues.currentValue;
      if ((this.dropdownValues.filter(x => x.id == null) < 1)) {
        this.dropdownValues.unshift(
          {
            id: null,
            text: `  -- Select ${this.label} --`
          }
        )
      }
    }
  }

}
