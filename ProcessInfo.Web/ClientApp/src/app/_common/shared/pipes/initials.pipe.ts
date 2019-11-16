import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'initials'
})
export class InitialsPipe implements PipeTransform {

  transform(name: string): string {
    if (name != undefined) {
      return name.split(" ").map((x) => x[0]).join(".")
    }
  }

}
