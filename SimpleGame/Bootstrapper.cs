using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Castle.Windsor;
using SimpleGame.Models;
using Castle.MicroKernel.Registration;

namespace SimpleGame
{
	public class Bootstrapper
	{
		private readonly IWindsorContainer container;

		public Bootstrapper()
		{
			container = new WindsorContainer();
		}

		public void Register()
		{
			container.Register(
				Component.For<DGetStat>().Instance(XmlStatParser.GetStat),
				Component.For<DGetItemStat>().UsingFactoryMethod<DGetItemStat>(kernel => ItemStats.GetStat(
					kernel.Resolve<DGetStat>(),
					SimpleGame.Properties.Resources.items)),
				Component.For<IDictionary<string, DGetItem<Item>>>().UsingFactoryMethod(kernel => new Dictionary<string, DGetItem<Item>>() { 
				{ "armour", ItemGenerator.GetArmour(kernel.Resolve<DGetItemStat>(), SimpleGame.Properties.Resources.armour_image) },
				{ "consumable", ItemGenerator.GetConsumable(kernel.Resolve<DGetItemStat>(), SimpleGame.Properties.Resources.potion_image)},
				{ "weapon", ItemGenerator.GetWeapon(kernel.Resolve<DGetItemStat>(), SimpleGame.Properties.Resources.weapon_image)}
				}),
				Component.For<DGetItem<Item>>().UsingFactoryMethod<DGetItem<Item>>(kernel => ItemGenerator.GetItem(
					kernel.Resolve<DGetItemStat>(),
					kernel.Resolve<IDictionary<string, DGetItem<Item>>>(),
					ItemGenerator.GetDefaultItem(kernel.Resolve<DGetItemStat>()))),
				Component.For<Game>().ImplementedBy<Game>(),
				Component.For<DIdExists>().Instance(XmlStatParser.IDExists),
				Component.For<MonsterStats>().ImplementedBy<MonsterStats>().DependsOn(new { statsFile = SimpleGame.Properties.Resources.monsters }),
				Component.For<DGetMonsterStat>().UsingFactoryMethod(kernel => kernel.Resolve<MonsterStats>().GetStat(kernel.Resolve<DGetStat>())),
				Component.For<DMonsterExists>().UsingFactoryMethod(kernel => kernel.Resolve<MonsterStats>().Exists(kernel.Resolve<DIdExists>())),
				Component.For<MonsterRepository>().ImplementedBy<MonsterRepository>().DependsOn(new {rabbit_image = SimpleGame.Properties.Resources.rabbit_image}),
				Component.For<MainMenu>().ImplementedBy<MainMenu>());
		}

		public Form ResolveForm()
		{
			return container.Resolve<MainMenu>();
		}

		public void Release(Form form)
		{
			container.Release(form);
		}
	}
}
