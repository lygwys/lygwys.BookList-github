import { MenuItem } from '@yoyo/theme';

// 全局的左侧导航菜单
export class AppMenus {
  static Menus = [
    // 首页
    new MenuItem('HomePage', '', 'anticon anticon-home', '/app/home'),
    // 租户
    new MenuItem(
      'Tenants',
      'Pages.Tenants',
      'anticon anticon-team',
      '/app/tenants',
    ),
    // 角色
    new MenuItem(
      'Roles',
      'Pages.Roles',
      'anticon anticon-safety',
      '/app/roles',
    ),
    // 用户
    new MenuItem('Users', 'Pages.Users', 'anticon anticon-user', '/app/users'),
    // 关于我们
    new MenuItem('About', '', 'anticon anticon-info-circle-o', '/app/about'),
    // 书单
    new MenuItem('ClouldBooklist', '', 'anticon anticon-switcher', '', [
      new MenuItem(
        'Book',
        'Pages.Book',
        'anticon anticon-dashboard',
        '/app/cloud-book-list/book',
      ),
      new MenuItem(
        'BookTag',
        'Pages.BookTag',
        'anticon anticon-dashboard',
        '/app/cloud-book-list/book-tag',
      ),
      new MenuItem(
        'CloudBookList',
        'Pages.CloudBookList',
        'anticon anticon-dashboard',
        '/app/cloud-book-list/cloud-book-list',
      ),
    ]),
  ];
}
