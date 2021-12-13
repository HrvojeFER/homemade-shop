
import "jquery";
import "jquery-validation";
import "jquery-validation-unobtrusive";
import "popper.js";
import "bootstrap";

import * as $ from "jquery";
$(() => {
    const updateCijena = async (predmet: string) => {
        const salveta = $(`[data-moguce-salvete=${predmet}]`).val();
        const ukras = $(`[data-moguce-ukrasavanje=${predmet}]`).val();
        var cijena = await $.ajax(`/Ponuda/DobiCijenu?idPredmet=${predmet}&idSalveta=${salveta}&idUkras=${ukras}`);
        if (cijena != "") {
            $(`[data-submit-kupi=${predmet}]`).removeAttr("disabled");
        } else {
            $(`[data-submit-kupi=${predmet}]`).attr("disabled", "disabled");
        }
        $(`[data-cijena=${predmet}]`).html(cijena);
    };
    $("[data-moguce-salvete]").change(async (e, j) => {
        const slectedItem = (e.currentTarget as HTMLSelectElement).value;
        const predment = e.currentTarget.dataset.moguceSalvete;
        var moguciUkrasi = await $.ajax(`/Ponuda/GetValidStiloviUkrasavanja?idPredmet=${predment}&idSalveta=${slectedItem}`);
        $(`[data-mu=${predment}]`).html(moguciUkrasi);
        var info = await $.ajax(`/Ponuda/GetSalvetaInfo?idSalveta=${slectedItem}`);
        $(`[data-ms-opis=${predment}]`).html(info);
        $(`[data-mu-opis=${predment}]`).html("");
        await updateCijena(predment);

    });
    $("[data-sve]").on("change", "[data-moguce-ukrasavanje]", async (e, j) => {
        console.log(e);
        const slectedItem = (e.currentTarget as HTMLSelectElement).value;
        const predment = e.currentTarget.dataset.moguceUkrasavanje;
        var info = await $.ajax(`/Ponuda/GetUkrasavanjeInfo?idUkras=${slectedItem}`);
        $(`[data-mu-opis=${predment}]`).html(info);
        await updateCijena(predment);
    });
    $("[data-filter-narudzbe]").click(async (e, i) => {
        if (!e)
            return;
        var filter = $(e.currentTarget).data("filterNarudzbe");
        var res = await $.ajax(`/Narudzbe/FilterNarudzbe?filter=${filter}`, { method: "get" });
        $("#narudzbe").html(res);
    });
    $("body").on("click", "[data-get-comments]", async (e, j) =>  {
        var curTarget = $(e.currentTarget);
        if (curTarget.hasClass("krc"))
            return;
        curTarget.addClass("krc");
        var id = curTarget.data("getComments");
        var comments = await $.ajax(`/Price/GetComments?roditelj=${id}`, {method: "get"});
        $(`[data-komentari-za=${id}]`).html(comments);
    });
    $("body").on("click", "[data-focus]", async (e, j) => {
        var curTarget = $(e.currentTarget);
        var id = curTarget.data("focus");
        var commentRoot = $(`[data-comment-root=${id}]`);
        $(`#root`).html(commentRoot.html());
    });
    $("body").on("click", "[data-get-roditelj]", async (e, j) => {
        try {
            var curTarget = $(e.currentTarget);
            var id = curTarget.data("getRoditelj");
            var roditelj = $(await $.ajax(`/Price/GetRoditelj?idPrice=${id}`, { method: "get" }));
            var curRoot = $(`#root`).html();
            roditelj
                .find("[data-komentari-za]")
                .addClass("show")
                .html(curRoot);

            $("#root").html(roditelj.html());
        } catch (ex) {
            window.location.reload();
        }
    });
});