import { BookTagEditDto } from '@shared/service-proxies/service-proxies';
import {
  BookTagServiceProxy,
  CreateOrUpdateBookTagInput,
} from './../../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import {
  Component,
  OnInit,
  ViewChild,
  Output,
  EventEmitter,
  Injector,
  Input,
} from '@angular/core';
import { NzSelectComponent } from 'ng-zorro-antd';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-booktag-nzselect',
  templateUrl: './booktag-nzselect.component.html',
  styles: [],
})
export class BooktagNzselectComponent extends AppComponentBase
  implements OnInit {
  @ViewChild('booktagselect') booktagselect: NzSelectComponent;

  @Output()
  selectedDataChange = new EventEmitter();

  @Input()
  set tagsSourceData(value: any) {
    // 绑定了父组件的属性<app-booktag-nzselect name="tag" [tagsSourceData]="tags"，其实是将父的tags传给了子的value
    this.isLoading = true;
    if (value) {
      this.listOfTagOptions = value;
      this.listOfSelectedValue = [];
      this.listOfTagOptions.forEach(item => {
        if (item.isSelected) {
          this.listOfSelectedValue.push(item.id);
        }
      });
    }

    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedValue);
    }

    this.isLoading = false;
  }
  isLoading = true;
  listOfTagOptions = [];
  listOfSelectedValue = [];
  searchValue = '';

  constructor(
    injector: Injector,
    private _booktagService: BookTagServiceProxy,
  ) {
    super(injector);
  }

  handleInputConfirm(): void {
    // 过滤掉已存在的值
    const booktagselectValues = this.booktagselect.listOfSelectedValue;
    for (let index = 0; index < booktagselectValues.length; index++) {
      const element = booktagselectValues[index];
      if (typeof element === 'number') {
        console.log('已存在于服务器的值');
      } else {
        // 检查当前用户是否有权限创建booktag
        if (this.permission.isGranted('Pages.BookTag.Create')) {
          this.isLoading = true;
          const BookTageditDto: BookTagEditDto = new BookTagEditDto();
          BookTageditDto.tagName = element;

          this._booktagService
            .create(BookTageditDto) // 修改了后端方法，有了多返回值 C#7.0 新特性
            .pipe(finalize(() => (this.isLoading = false)))
            .subscribe(res => {
              // console.log(res);
              const listOfSelectedValues = this.listOfSelectedValue;
              const listOfTagOptions = this.listOfTagOptions;
              for (
                let selectIndex = 0;
                selectIndex < listOfSelectedValues.length;
                selectIndex++
              ) {
                if (res.tagName === listOfSelectedValues[selectIndex]) {
                  listOfTagOptions.push(res);
                  listOfSelectedValues[selectIndex] = res.id;
                }
              }
            });
        }
      }
    }
  }

  modelChange(): void {
    if (this.selectedDataChange) {
      this.selectedDataChange.emit(this.listOfSelectedValue);
    }
  }

  ngOnInit(): void {}
}
