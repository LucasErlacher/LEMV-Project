import { shallowMount } from '@vue/test-utils'
import AdminCard from '../../src/components/Card/adminCard.vue'
import { useRouter } from 'vue-router'

describe('UNIT TEST', () => {
  it('componente definido', () => {
    const wrapper = shallowMount(AdminCard, {
      props: { alias: 'a', description: 'b' },
      global: {
        plugins: [useRouter]
      }
    })
    expect(wrapper.vm).toBeDefined()
  })
})
