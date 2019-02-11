import { Component, OnInit, Injector } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base';
import { Inject } from '@angular/compiler/src/core';

@Component({
  selector: 'app-img-show',
  templateUrl: './img-show.component.html',
  styles: [],
})
export class ImgShowComponent extends ModalComponentBase {
  imgUrl = '';
  constructor(injector: Injector) {
    super(injector);
  }
}
