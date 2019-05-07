import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {

    menuItems: MenuItem[] = [
        new MenuItem(this.l('HomePage'), '', 'home', '/app/home'),
        new MenuItem(this.l('机器状态'), '', 'business', '/app/testcases'),
        new MenuItem(this.l('test'), '', 'business', '/app/machine'),
        new MenuItem(this.l('棉包入库'), '', 'people', 'http://www.litaitextile.com/'),
        new MenuItem(this.l('智能配棉'), '', 'local_offer', 'http://www.litaitextile.com/'),
        new MenuItem(this.l('产品出库'), '', 'info', 'http://www.litaitextile.com/'),

        new MenuItem(this.l('利泰库尔勒'), '', 'menu', '', [
            new MenuItem('1#气流纺工厂', '', 'menu', '', [
                new MenuItem('机器状态', '', 'info', 'http://www.litaitextile.com/'),
                new MenuItem('停锭时间', '', 'info', 'http://www.litaitextile.com/'),
                new MenuItem('停锭频次', '', 'info', 'http://www.litaitextile.com/' ),
                new MenuItem('我的设置', '', 'info', 'http://www.litaitextile.com/'),
            ]),
            new MenuItem('2#气流纺工厂', '', 'menu', '', [
                new MenuItem('机器状态', '', 'info', 'http://www.litaitextile.com/'),
                new MenuItem('停锭时间', '', 'info', 'http://www.litaitextile.com/'),
                new MenuItem('停锭频次', '', 'info', 'http://www.litaitextile.com/' ),
                new MenuItem('我的设置', '', 'info', 'http://www.litaitextile.com/'),
            ]),
            new MenuItem('3#气流纺工厂', '', 'menu', '', [
                new MenuItem('机器状态', '', 'info', 'http://www.litaitextile.com/'),
                new MenuItem('停锭时间', '', 'info', 'http://www.litaitextile.com/'),
                new MenuItem('停锭频次', '', 'info', 'http://www.litaitextile.com/' ),
                new MenuItem('我的设置', '', 'info', 'http://www.litaitextile.com/'),
            ])
        ]),

        new MenuItem(this.l('系统管理'), '', 'menu', '', [
            new MenuItem('用户角色', '', 'menu', '', [
                new MenuItem(this.l('租户'), 'Pages.Tenants', 'business', '/app/tenants'),
                new MenuItem(this.l('用户'), 'Pages.Users', 'people', '/app/users'),
                new MenuItem(this.l('角色'), 'Pages.Roles', 'local_offer', '/app/roles'),
            ])
        ]),
        new MenuItem(this.l('关于'), '', 'info', '/app/about'),
    ];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }
}
