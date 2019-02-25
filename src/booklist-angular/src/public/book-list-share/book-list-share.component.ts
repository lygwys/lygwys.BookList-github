import { BookListDto } from './../../shared/service-proxies/service-proxies';
import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/component-base';

@Component({
  selector: 'app-book-list-share',
  templateUrl: './book-list-share.component.html',
  styles: [],
})
export class BookListShareComponent extends AppComponentBase implements OnInit {
  id: number;
  tid: number;
  loading = false;
  entity: BookListDto;
  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInit() {}
}
