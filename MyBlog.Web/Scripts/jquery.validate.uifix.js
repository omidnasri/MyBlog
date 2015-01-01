﻿function removeAllTagsAndTrim(html) {
    return !html ? "" : $.trim(html.replace(/(<([^>]+)>)/ig, ""));
}

function validateEditor(id, triggerValidation) {
    if (triggerValidation) {
        $('form').valid();
        return;
    }
    //CKEDITOR.instances.Description.updateElement();
    var content = CKEDITOR.instances[id].getData().replace(/(<([^>]+)>)/ig, '');
    content = content.replace(/&nbsp;/gi, '');
    var editorArea = $('#cke_' + id);
    //var errorSpan = $('#descriptionError');

    if ($.trim(content).length === 0) {
        $(editorArea).parent('div.input-control').removeClass('success').addClass('error-state');
        //$(errorSpan).addClass('field-validation-error').removeClass('field-validation-valid')
        //.css('display', 'inline-block').html('<span for="Description" class="">Description has required.</span>');
        return false;
    }

    //$(errorSpan).css('display', 'none').html('');
    //$(editorArea).removeClass('input-validation-error').addClass('field-validation-valid').addClass('valid');
    return true;
}

$.validator.setDefaults({
    ignore: ":hidden:not(textarea)",
    highlight: function (element) {
        $(element).closest('.input-control').addClass('error-state');
    },
    unhighlight: function (element) {
        if ($(element).is('textarea:hidden')) {
            $(element).closest('.finput-control').addClass('success').removeClass('error-state');
        } else {
            $(element).attr('data-state', 'success').closest('.finput-control').removeClass('error-state');
        }
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});

// این تنظیم برای پردازش ادیتور مخفی وب لازم است
$.validator.setDefaults({});

// متد اصلی اعتبارسنجی را ابتدا ذخیره می‌کنیم
$.validator.methods.originalRequired = $.validator.methods.required;
// نحوه بازنویسی متد توکار اعتبار سنجی جهت استفاده از یک متد سفارشی
$.validator.addMethod("required", function (value, element, param) {
    if ($(element).is('textarea:hidden')) {
        return validateEditor($(element).attr('id'), false);
    } else {
        value = removeAllTagsAndTrim(value);
        if (!value) {
            return false;
        }
    }
    //  فراخوانی متد اصلی اعتبار سنجی در صورت شکست تابع سفارشی
    return $.validator.methods.originalRequired.call(this, value, element, param);
}, $.validator.messages.required);

$(function () {
    $('form').each(function () {
        $(this).find('div.input-control').each(function () {
            if ($(this).find('span.field-validation-error').length > 0) {
                $(this).addClass('error-state');
            }
        });
    });
    setTimeout(function () {
        for (var i in CKEDITOR.instances) {
            /* this returns the names of the textareas/id of the instances. */
            var name = CKEDITOR.instances[i].name;
            var editor = $('.cke_wysiwyg_frame').contents().find('body.cke_editable');
            if (editor.length > 0) {
                $(editor).keyup(function () {
                    validateEditor(name, true);
                });
            }
        }
    }, 2000);
});