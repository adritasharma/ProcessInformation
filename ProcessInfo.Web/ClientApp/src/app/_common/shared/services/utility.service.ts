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

  getArrayFromEnum(input: any) {
    return (Object.keys(input)).filter(value => isNaN(Number(value)) === false)
      .map(key => ({ label: input[key], value: Number(key) }))
  }
}
