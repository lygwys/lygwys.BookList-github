import { NzSelectComponent } from 'ng-zorro-antd';
import { AppComponentBase } from '@shared/component-base/app-component-base';
import {
  Component,
  OnInit,
  Inject,
  Injector,
  ViewChild,
  EventEmitter,
  Output,
  Input,
} from '@angular/core';
import { inject } from '@angular/core/testing';

@Component({
  selector: 'app-book-nzselect',
  templateUrl: './book-nzselect.component.html',
  styles: [],
})
export class BookNzselectComponent extends AppComponentBase implements OnInit {
  constructor(injector: Injector) {
    super(injector);
  }

  @ViewChild('select') select: NzSelectComponent;
  @Output()
  selectedDataChange = new EventEmitter();

  @Input()
  bookSourceDataChange = new EventEmitter();

  isLoading = true;
  listOfTagOptions = [];

  listOfSelectedValue = [];

  @Input()
  set bookSourceData(value: any) {}

  ngOnInit() {}
}
