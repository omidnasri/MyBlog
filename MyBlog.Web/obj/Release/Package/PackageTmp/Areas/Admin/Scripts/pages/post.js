﻿$(function () {
    CKEDITOR.replace('Post_Content', {
        contentsLangDirection: 'rtl',
        filebrowserImageUploadUrl: '/base/uploadimage'
    });

    setTimeout(function () { $('.cke_top').addClass('cke_rtl'); }, 1000);
});

function initializeTagsInput(tagsToAdd) {
    var tags = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('text'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: '/post/gettags'
    });
    tags.initialize();

    var elt = $('#Tags');
    elt.tagsinput({
        itemValue: 'value',
        itemText: 'text',
        typeaheadjs: {
            name: 'tags',
            displayKey: 'text',
            source: tags.ttAdapter()
        }
    });

    if (typeof tagsToAdd === 'undefined') {
        return;
    }

    $.each(tagsToAdd, function (index, tag) {
        elt.tagsinput('add', { 'value': tag.value, 'text': tag.text });
    });

    $('.bootstrap-tagsinput').addClass('left-text form-control').css({ 'border-radius': '0', 'width': '100%;' });
}