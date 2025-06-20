namespace Horizons.Web.Controllers
{
    using Horizons.Data.Models;
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
                    this.ModelState.AddModelError(string.Empty, "Something wen wrong, try again!");
                    //return this.RedirectToAction(nameof(Add));

                    destinationAddViewModel.PublishedOn = DateTime.UtcNow.ToString(DateTimeFormat);
                    destinationAddViewModel.Terrains = await this.terrainService.GetAllTerrainsDropDownAsync();
                     return this.View(destinationAddViewModel); // Witch will return the view with the model errors displayed!
                }

                string userId = this.GetUserId()!;
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
        public async Task<IActionResult> Edit(DestinationEditViewModel destinationEditVM)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.RedirectToAction(nameof(Edit), new { id = destinationEditVM.Id });

                    // return this.View(destinationEditViewModel); // Witch will return the view with the model errors displayed!
                }

                string? userId = this.GetUserId();
                bool isDestinationEdited = await this.destinationService
                    .EditDestinationAsync(destinationEditVM, userId);

                if (isDestinationEdited == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Destination could not be edited. Please try again.");
                    return this.View(destinationEditVM);
                }

                return this.RedirectToAction(nameof(Details), new { Id = destinationEditVM.Id });
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
                    this.ModelState.AddModelError(string.Empty, "Please do not modify this destination!");
                    return this.View(destinationDeleteVM);

                    // return this.View(destinationDeleteVM); // With this will return the view with the model errors displayed!
                }

                string userId = this.GetUserId()!;

                bool isDestinationDeleted = await this.destinationService
                    .SoftDeleteDestinationAsync(destinationDeleteVM, userId);


                if (isDestinationDeleted == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occured. Please try again.");
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

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = this.GetUserId()!;

                IEnumerable<DestinationFavoriteViewModel> favoriteDestinationList = await this.destinationService
                    .GetAllFavoriteDestinationsListAsync(userId);


                if (favoriteDestinationList == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(favoriteDestinationList);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int? id, string returnTo)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool isAddedToFavorite = await this.destinationService
                    .AddToFavoriteListAsync(id.Value, userId);


                if (isAddedToFavorite == false || returnTo == "Index")
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction("Details", new { id = id });

                //return this.RedirectToAction(nameof(Favorites)); //Original return to Favorites page

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                bool isRemovedFromFavorite = await this.destinationService
                    .RemoveFavoriteFromListAsync(id.Value, userId);


                if (isRemovedFromFavorite == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Favorites));
                //When a user removes a favorite destination from the list, the application should update the view without redirecting the user
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
