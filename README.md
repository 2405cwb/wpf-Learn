
## CwbControls
1. wpf自定义控件
   1. 设计了一个自己的button控件，控件增加依赖属性圆角
## SimpleDataManager001
1. 模拟创建一个增删改查的界面程序
   1. 使用Prism框架.
## UserControlDemo
1. 使用自定义控件  
   1. 实现动画效果 通过动画的slider来控制自定义按钮的圆角效果
   2. 使用附加属性 实现动画效果的修改依赖属性
2. 使用数据绑定和方法绑定 ItemsControl
   1. 属性快捷键入 cmd
   2. 使用了依赖属性的双向通知
   3. 使用了方法的校验方法
   4.
   ```csharp
   private DelegateCommand<Test> _fieldName;
   public DelegateCommand<Test> CommandName =>
      _fieldName ?? (_fieldName = new DelegateCommand<Test>(ExecuteCommandName).ObservesCanExecute(() => IsEnabled)); 
       //_fieldName ?? (_fieldName = new DelegateCommand<Test>(ExecuteCommandName));

   void ExecuteCommandName(Test parameter)
   {
       MessageBox.Show($"You clicked {parameter.Name}!");
   }
   ```
   5. https://www.bilibili.com/video/BV1Z5411y7mg?spm_id_from=333.788.player.switch&vd_source=c6341ba8c0f1a12df7b867500e06d5de
## TestDialog
1. 使用prism的对话框服务
2. 使用prism的事件聚合器
## Prism选项卡导航
1. 使用prism进行页面导航
2. 使用 赋予窗体基本功能
'''cShape
<WindowChrome.WindowChrome>
        <WindowChrome CaptionHeight="30" CornerRadius="10" />
    </WindowChrome.WindowChrome>
'''
3. 使用font-awsome字体库
## 平台模板
1. 构建通用平台类模板
	1. 使用md构建统一样式，添加颜色管理菜单，右侧隐藏菜单等
	2. 使用DryIoc进行依赖注入管理
	3. 使用Prism框架构建对话服务，mvvm等