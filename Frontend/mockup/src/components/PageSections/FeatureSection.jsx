import {
  BanknotesIcon,
  UserIcon,
  ChatBubbleLeftIcon,
} from "@heroicons/react/20/solid";

const features = [
  {
    name: "Registreer je nu!",
    description: "Vul je gegevens in en upload foto's van je auto.",
    icon: UserIcon,
  },
  {
    name: "Wacht op oproepen.",
    description: "Productiehuizen kunnen je auto reserveren voor filmopnames.",
    icon: ChatBubbleLeftIcon,
  },
  {
    name: "Verdien geld.",
    description: "Krijg betaald voor het beschikbaar stellen van je auto.",
    icon: BanknotesIcon,
  },
];

export default function FeatureSection() {
  return (
    <div className="overflow-hidden bg-white py-10 sm:py-32">
      <div className="ml-32 max-w-7xl px-6 lg:px-8">
        <div className="mx-auto grid max-w-2xl grid-cols-1 gap-x-40 gap-y-16 sm:gap-y-20 lg:mx-0 lg:max-w-none lg:grid-cols-2">
          <div className="lg:pr-8 lg:pt-4">
            <div className="lg:max-w-lg">
              <h2 className="text-base font-semibold leading-7 text-blue-600">
                Zoek sneller
              </h2>
              <p className="mt-2 text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">
                vindt sneller!
              </p>
              <p className="mt-6 text-lg leading-8 text-gray-600">
                Stel je auto beschikbaar voor filmproducties en verdien een leuk
                bedrag! Jouw voertuig kan de ster zijn in de volgende grote
                film, terwijl jij geniet van extra inkomsten. Meld je vandaag
                nog aan en maak van jouw auto een filmicoon!
              </p>
              <dl className="mt-10 max-w-xl space-y-8 text-base leading-7 text-gray-600 lg:max-w-none">
                {features.map((feature) => (
                  <div key={feature.name} className="relative pl-9">
                    <dt className="inline font-semibold text-gray-900">
                      <feature.icon
                        className="absolute left-1 top-1 h-5 w-5 text-blue-600"
                        aria-hidden="true"
                      />
                      {feature.name}
                    </dt>{" "}
                    <dd className="inline">{feature.description}</dd>
                  </div>
                ))}
              </dl>
            </div>
          </div>
          <img
            src="src\images\CarKeys.jpg"
            alt="Product screenshot"
            className="w-[48rem] max-w-none rounded-xl shadow-xl ring-1 ring-gray-400/10 sm:w-[57rem] md:-ml-4 lg:-ml-0"
            width={2432}
            height={1442}
          />
        </div>
      </div>
    </div>
  );
}
