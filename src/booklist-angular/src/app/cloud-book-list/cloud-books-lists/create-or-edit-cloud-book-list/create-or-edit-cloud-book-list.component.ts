import { BookSelectListDto } from './../../../../shared/service-proxies/service-proxies';
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
  CreateOrUpdateCloudBookListInput,
  CloudBookListEditDto,
  CloudBookListServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { Validators, AbstractControl, FormControl } from '@angular/forms';

@Component({
  selector: 'create-or-edit-cloud-book-list',
  templateUrl: './create-or-edit-cloud-book-list.component.html',
  styleUrls: ['create-or-edit-cloud-book-list.component.less'],
})
export class CreateOrEditCloudBookListComponent extends ModalComponentBase
  implements OnInit {
  /**
   * 编辑时DTO的id
   */
  id: any;

  entity: CloudBookListEditDto = new CloudBookListEditDto();
  books: any = []; //
  selectBooks: any = []; //
  /**
   * 初始化的构造函数
   */
  constructor(
    injector: Injector,
    private _cloudBookListService: CloudBookListServiceProxy,
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.init();
  }

  /**
   * 初始化方法
   */
  init(): void {
    this._cloudBookListService.getForEdit(this.id).subscribe(result => {
      this.entity = result.cloudBookList;
      this.books = result.books; //
    });
  }

  /**
   * 保存方法,提交form表单
   */
  submitForm(): void {
    const input = new CreateOrUpdateCloudBookListInput();
    input.cloudBookList = this.entity;

    input.bookIds = this.selectBooks; //

    this.saving = true;

    this._cloudBookListService
      .createOrUpdate(input)
      .finally(() => (this.saving = false))
      .subscribe(() => {
        this.notify.success(this.l('SavedSuccessfully'));
        this.success(true);
      });
  }

  bookSelectChange(data: any) {
    this.selectBooks = data;
  }
}
