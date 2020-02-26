import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Observable, of } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'input-chip',
  templateUrl: './custom-input-chip.component.html',
  styleUrls: ['./custom-input-chip.component.css']
})
export class CustomInputChipComponent implements OnInit {

  constructor(public _http: HttpClient) {
  }
  @Input() AutocompleteItems?: any[];
  @Input() Options: any;
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

  public requestAutocompleteItems = (text: string): Observable<any> => {
    const url = `${environment.apiUrl}user/search/${text}`;
    ;
    return this._http
      .get(url);

    // return of([{userId: "one",firstName:"one"}])
  };

  itemsAsObjects = [{userId: "one",firstName:"one"}]

}
