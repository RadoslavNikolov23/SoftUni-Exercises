namespace Horizons.Web.Controllers
{
    using Horizons.Services.Core.Contracts;
    using Horizons.Web.ViewModels.Destinations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static Horizons.GCommon.ValidationConstants.DestinationConst;


    public class DestinationController : BaseController
    {
        private readonly IDestinationService destinationService;
        private readonly ITerrainService terrainService;

        public DestinationController(IDestinationService destinationService, ITerrainService terrainService)
        {
            this.destinationService = destinationService;
            this.terrainService = terrainService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = this.GetUserId();
                IEnumerable<DestinationViewModel> destinations = await this.destinationService.GetAllDestinationsAsync(userId);

                return this.View(destinations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                string? userId = this.GetUserId();

                DestinationDetailViewModel? destinationDetailVM = await this.destinationService.GetDestinationByIdAsync(id, userId);

                if (destinationDetailVM == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(destinationDetailVM);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                DestinationAddViewModel destinationAddViewModel = new DestinationAddViewModel
                {
                    PublishedOn = DateTime.UtcNow.ToString(DateTimeFormat),
                    Terrains = await this.terrainService.GetAllTerrainsDropDownAsync()
                };

                return this.View(destinationAddViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }


        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationAddViewModel destinationAddViewModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.RedirectToAction(nameof(Add));
                    // return this.View(destinationEditViewModel); // With this will return the view with the model errors displayed!
                }

                string? userId = this.GetUserId();
                bool isAddedSuccessfully = await this.destinationService
                    .AddDestinationAsync(destinationAddViewModel, userId);

                if (!isAddedSuccessfully)
                {
                    this.ModelState.AddModelError(string.Empty, "Destination could not be added. Please try again.");
                    return this.RedirectToAction(nameof(Add));

                }
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string? userId = this.GetUserId();

                DestinationEditViewModel? destinationEditVM = await this.destinationService.GetDestinationForEditAsync(id, userId);

                if (destinationEditVM == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                destinationEditVM!.Terrains = await this.terrainService.GetAllTerrainsDropDownAsync();

                return this.View(destinationEditVM);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DestinationEditViewModel destinationEditViewModel)
        {
            try
            {
            //Changing to ! opposite
                if (!this.ModelState.IsValid)
                {
                    return this.RedirectToAction(nameof(Edit), new { id = destinationEditViewModel.Id });

                    // return this.View(destinationEditViewModel); // With this will return the view with the model errors displayed!
                }

                string? userId = this.GetUserId();
                bool isDestinationEdited = await this.destinationService
                    .EditDestinationAsync(destinationEditViewModel, userId);


                if (isDestinationEdited == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Destination could not be edited. Please try again.");
                    return this.View(destinationEditViewModel);
                }

                return this.RedirectToAction(nameof(Details), new { Id = destinationEditViewModel.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                DestinationDeleteViewModel? destinationDeleteVM = await this.destinationService.GetDestinationForDeleteAsync(id, userId);

                if (destinationDeleteVM == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(destinationDeleteVM);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DestinationDeleteViewModel destinationDeleteVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.ModelState.AddModelError(string.Empty, "Please do not modife this destination!");
                    return this.View(destinationDeleteVM)
                    
                    //return this.RedirectToAction(nameof(Delete), new { id = destinationDeleteVM.Id }); // Maybe this?

                    // return this.View(destinationDeleteVM); // With this will return the view with the model errors displayed!
                }

                string userId = this.GetUserId()!;

                bool isDestinationDeleted = await this.destinationService
                    .SoftDeleteDestinationAsync(destinationDeleteVM, userId);


                if (isDestinationDeleted == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Destination could not be deleted. Please try again.");
                    return this.View(destinationDeleteVM);
                }

                return this.RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
