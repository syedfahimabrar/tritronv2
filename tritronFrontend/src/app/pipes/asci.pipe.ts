import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'asci' })
export class AsciPipe implements PipeTransform {
  constructor() {}

  public transform(value: number) {
    return String.fromCharCode(value);
  }
}
