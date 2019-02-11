import {
  Component,
  OnInit,
  Injector,
  Input,
  ViewChild,
  AfterViewInit,
} from '@angular/core';
import { ModalComponentBase } from '@shared/component-base/modal-component-base';
import {
  CreateOrUpdateBookInput,
  BookEditDto,
  BookServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'create-or-edit-book',
  templateUrl: './create-or-edit-book.component.html',
  styleUrls: ['create-or-edit-book.component.less'],
})
export class CreateOrEditBookComponent extends ModalComponentBase
  implements OnInit {
  /**
   * 编辑时DTO的id
   */
  id: any;

  tags: any; // 所有书籍的标签
  selectedTages: any = []; // 已选择的标签集合
  entity: BookEditDto = new BookEditDto();

  /**
   * 初始化的构造函数
   */
  constructor(injector: Injector, private _bookService: BookServiceProxy) {
    super(injector);
  }

  ngOnInit(): void {
    this.init();
  }

  /**
   * 初始化方法
   */
  init(): void {
    this._bookService.getForEdit(this.id).subscribe(result => {
      this.entity = result.book;
      this.tags = result.bookTags;
    });
  }

  /**
   * 保存方法,提交form表单
   */
  submitForm(): void {
    const input = new CreateOrUpdateBookInput();
    input.book = this.entity;

    this.saving = true;

    input.tagIds = this.selectedTages;

    this._bookService
      .createOrUpdate(input)
      .finally(() => (this.saving = false))
      .subscribe(() => {
        this.notify.success(this.l('SavedSuccessfully'));
        this.success(true);
      });
  }

  /**
   * 获取选择的tag值
   */
  tagSelectChange(data: any[]) {
    this.selectedTages = data;
  }
}
