(function ($) {
    app.modals.CreateModel = function () {
       
        var modelService = abp.services.app.model;
        var _$modelForm = null;

        var _modalManager;
        this.init = function (modalManager) {
            _modalManager = modalManager;
            //取出form表单
            _$modelForm = _modalManager.getModal().find("form[name=ContentModelForm]");

            _$modelForm.validate();
        };

        this.save = function () {
            if (!_$modelForm.valid()) {
                return;
            }
            //序列化参数
            var model = _$modelForm.serializeFormToObject();
            _modalManager.setBusy(true);
          
            modelService.createOrUpdate(model).done(function () {
                abp.notify.info("添加成功");
                _modalManager.close();
                abp.event.trigger('app.createModelSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };


    app.modals.EditModel = function () {

        var _modalManager;
        var modelService = abp.services.app.model;

        var _$modelForm = null;

        var _modalManager;
        this.init = function (modalManager) {
            _modalManager = modalManager;
            //取出form表单
            _$modelForm = _modalManager.getModal().find("form[name=ContentModelForm]");

            _$modelForm.validate();
        };


        this.save = function () {
            if (!_$modelForm.valid()) {
                return;
            }

            var model = _$modelForm.serializeFormToObject();

            _modalManager.setBusy(true);
            modelService.createOrUpdate(
                model
            ).done(function () {
                abp.notify.info("修改成功");
                _modalManager.close();
                abp.event.trigger('app.editModelSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery)