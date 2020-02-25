import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Observable, of } from 'rxjs';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-custom-input-chip',
  templateUrl: './custom-input-chip.component.html',
  styleUrls: ['./custom-input-chip.component.css']
})
export class CustomInputChipComponent implements OnInit {

  constructor() { }
  @Input() AutocompleteItems: any[];
  @Input() Options: any[];
  @Input() model: any;
  @Input() label: string;
  @Input() fieldId: string;
  @Input() required: boolean;

  @Output() modelChange = new EventEmitter();

  ngOnInit() { }

  public onAdd(item) {
    this.onModelChange();
  }

  public onRemove(item) {
    this.onModelChange();
  }

  public onAdding(tag): Observable<any> {
    const confirm =
      typeof tag == "string"
        ? window.confirm("Do you really want to add this tag?")
        : true;
    return of(tag).pipe(
      filter(() => confirm));
  }

  onModelChange() {
    console.log(this.model);
    this.modelChange.emit(this.model);
  }

}
