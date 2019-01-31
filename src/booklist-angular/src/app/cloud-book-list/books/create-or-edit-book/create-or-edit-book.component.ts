import {
  BookServiceProxy,
  BookEditDto,
  CreateOrUpdataBookInput,
} from './../../../../shared/service-proxies/service-proxies';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import { Component, OnInit, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-or-edit-book',
  templateUrl: './create-or-edit-book.component.html',
  styles: [],
})
export class CreateOrEditBookComponent extends ModalComponentBase
  implements OnInit {
  id: any;
  entity: BookEditDto = new BookEditDto();
  constructor(injector: Injector, private _bookService: BookServiceProxy) {
    super(injector);
  }

  ngOnInit() {
    this.init();
  }
  init(): void {
    // 编辑
    this._bookService.getForEditBookAsync(this.id).subscribe(res => {
      this.entity = res.book;
    });
  }

  // 保存方法
  submitForm(): void {
    const input = new CreateOrUpdataBookInput();
    input.book = this.entity;
    this.saving = true;
    this._bookService
      .createOrUpdateBook(input)
      .pipe(
        finalize(() => {
          this.saving = false;
        }),
      )
      .subscribe(() => {
        abp.notify.success('信息保存成功！！');
        this.success(true);
      });
  }
}
