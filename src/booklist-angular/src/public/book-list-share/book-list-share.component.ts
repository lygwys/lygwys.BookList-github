import { AbpSessionService } from '@yoyo/abp/session/abp-session.service';
import {
  BookListDto,
  BookServiceProxy,
  CloudBookListShareDto,
} from './../../shared/service-proxies/service-proxies';
import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/component-base';
import { ActivatedRoute } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { ShareQrcodeComponent } from '@shared/components/share-qrcode/share-qrcode.component';
import { AppConsts } from '@shared/AppConsts';

@Component({
  selector: 'app-book-list-share',
  templateUrl: './book-list-share.component.html',
  styles: [],
})
export class BookListShareComponent extends AppComponentBase implements OnInit {
  id: number;
  tid: number;
  loading = false;
  entity: CloudBookListShareDto;
  constructor(
    injector: Injector,
    private _activatedRoute: ActivatedRoute,
    private _bookService: BookServiceProxy,
  ) {
    super(injector);
  }

  ngOnInit() {
    this.id = this._activatedRoute.snapshot.params['id'];
    this.tid = this._activatedRoute.snapshot.params['tid'];
    // 查询数据
    if (this.tid && this.id) {
      this._bookService
        .getBookListShareAsync(this.id, this.tid)
        .pipe(
          finalize(() => {
            this.loading = false;
          }),
        )
        .subscribe(result => {
          this.entity = result;
        });
    }
  }

  // 分享二维码功能  从前面复制修改
  shareQrCode() {
    const tid = this.tid;
    const cloudbookListId = this.id;
    const url =
      AppConsts.appBaseUrl +
      '/public/book-list-share;tid=' +
      tid +
      ';id=' +
      cloudbookListId;
    this.modalHelper
      .open(ShareQrcodeComponent, { qrcodeUrl: url }, 'sm')
      .subscribe(() => {});
  }
}
