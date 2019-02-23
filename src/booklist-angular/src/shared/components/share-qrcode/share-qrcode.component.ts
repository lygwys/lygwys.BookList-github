import { Component, OnInit, Injector } from '@angular/core';
import { ModalComponentBase } from '@shared/component-base';

@Component({
  selector: 'app-share-qrcode',
  templateUrl: './share-qrcode.component.html',
  styles: [],
})
export class ShareQrcodeComponent extends ModalComponentBase {
  qrcodeUrl: string;
  constructor(injector: Injector) {
    super(injector);
  }
}
