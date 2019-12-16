import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'list-actions',
  templateUrl: './list-actions.component.html',
  styleUrls: ['./list-actions.component.css']
})
export class ListActionsComponent implements OnInit {

  constructor() { }

  @Input() modulePath: string;
  @Input() itemId: number;
  @Input() canEdit: boolean;
  @Input() canDelete: boolean;

  @Output() isDeleteClicked = new EventEmitter();

  editLink: any
  viewLink: any
  
  ngOnInit() {
    this.editLink = [`${this.modulePath}/Edit/${this.itemId}`]
    this.viewLink = [`${this.modulePath}/view/${this.itemId}`]
  }
  emitDelete() {
    this.isDeleteClicked.emit();
  }

}
