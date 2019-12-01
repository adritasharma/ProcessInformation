import { Injectable } from '@angular/core';
declare var $: any;

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor() { }

  convertToParam(json: any) {
    return $.param(json);
  }

}
